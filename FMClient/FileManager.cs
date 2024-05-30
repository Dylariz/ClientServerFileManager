using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMClient;

public partial class FileManager : Form
{
    private const string ServerUrl = "http://localhost:3000/";
        
    private Client _client;
    private string _currentPath = "/";
    private Stack<string> _backHistory = new();
    private Stack<string> _forwardHistory = new();
        
    public FileManager()
    {
        InitializeComponent();
        _client = new Client(ServerUrl);
        
    }
        
    private void FileManager_Load(object sender, EventArgs e)
    {
        if (!_client.CheckServerConnection().Result)
        {
            MessageBox.Show("Не удалось подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }
        
        FillListView("/").Wait();
    }
        
    // Отоюражение файлов и папок
    private async Task FillListView(string path)
    {
        var response = await _client.GetFiles(path).ConfigureAwait(false);
            
        if (response == null)
            return;
            
        BeginInvoke((Action) delegate
        {
            objectCount.Text = "Элементов: " + response.Count;
            pathTextBox.Text = response.Path;
            _currentPath = response.Path;
            
            fileView.Items.Clear();
            foreach (var file in response.Objects)
            {
                var item = new ListViewItem(file.Name); // Имя файла
                item.SubItems.Add(file.Timestamp); // Дата изменения файла
                item.SubItems.Add(file.Type); // Тип файла
                if (file.Size != null)
                    item.SubItems.Add(file.Size); // Размер файла
                
                fileView.Items.Add(item); // Добавляем элемент в ListView
            }
        });
    }

    // Кнопки перемещения по папкам
    private async void backButton_Click(object sender, EventArgs e)
    {
        if (_backHistory.Count == 0)
            return;
            
        _forwardHistory.Push(_currentPath);
        await FillListView(_backHistory.Pop()).ConfigureAwait(false);
    }

    private async void forwardButton_Click(object sender, EventArgs e)
    {
        if (_forwardHistory.Count == 0)
            return;
            
        _backHistory.Push(_currentPath);
        await FillListView(_forwardHistory.Pop()).ConfigureAwait(false);
    }
        
    private async void upFolderButton_Click(object sender, EventArgs e)
    {
        if (_currentPath == "/")
            return;
            
        var path = _currentPath.Substring(0, _currentPath.LastIndexOf("/", StringComparison.Ordinal));
        if (path == "")
            path = "/";
            
        _backHistory.Push(_currentPath);
        _forwardHistory.Clear();
        await FillListView(path).ConfigureAwait(false);
    }
        
    // Нажатие Enter в TextBox
    private async void pathTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            if (pathTextBox.Text == _currentPath)
                return;

            if (pathTextBox.Text.Contains("..") || pathTextBox.Text[0] != '/')
            {
                pathTextBox.Text = _currentPath;
                return;
            }
                
            _backHistory.Push(_currentPath);
            _forwardHistory.Clear();
            await FillListView(pathTextBox.Text).ConfigureAwait(false);
        }
    }
        
    // Двойное нажатие на файл
    private async void fileView_DoubleClick(object sender, EventArgs e)
    {
        if (fileView.SelectedItems.Count == 1)
        {
            if (fileView.SelectedItems[0].SubItems[2].Text == "Папка")
            {
                _backHistory.Push(_currentPath);
                _forwardHistory.Clear();
                await FillListView(_currentPath + "/" + fileView.SelectedItems[0].Text + "/").ConfigureAwait(false);
            }
        }
    }

    // Кнопки контекстного меню
    private async void downloadContextItem_Click(object sender, EventArgs e)
    {
        if (fileView.SelectedItems.Count == 1)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = fileView.SelectedItems[0].Text;
            dialog.Filter = "All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await _client.DownloadFile(_currentPath + "/" + fileView.SelectedItems[0].Text, dialog.FileName).ConfigureAwait(false);
            }
        }
    }
        
    private async void uploadContextItem_Click(object sender, EventArgs e)
    {
        // Открытие диалога для выбора файла
        var dialog = new OpenFileDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            await _client.UploadFile(_currentPath, dialog.FileName).ConfigureAwait(false);
            await FillListView(_currentPath).ConfigureAwait(false);
        }
    }

    private async void createFolderContextItem_Click(object sender, EventArgs e)
    {
        // Открытие диалога для ввода имени папки
        var dialog = new InputDialog("Введите имя папки:");
        if (dialog.ShowDialog() == DialogResult.OK && dialog.InputText != "" && dialog.InputText != ".." && dialog.InputText[0] != '/')
        {
            await _client.CreateFolder(_currentPath + "/" + dialog.InputText).ConfigureAwait(false);
            await FillListView(_currentPath).ConfigureAwait(false);
        }
    }
        
    private async void deleteContextItem_Click(object sender, EventArgs e)
    {
        if (fileView.SelectedItems.Count == 1)
        {
            var a = _currentPath + fileView.SelectedItems[0].Text;
            await _client.DeleteObject(_currentPath + "/" + fileView.SelectedItems[0].Text).ConfigureAwait(false);
            await FillListView(_currentPath).ConfigureAwait(false);
        }
    }
        
    private void fileView_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            if (fileView.SelectedItems.Count == 1)
            {
                if (fileView.SelectedItems[0].SubItems[2].Text == "Папка")
                {
                    folderContextMenu.Show(fileView, e.Location);
                }
                else
                {
                    fileContextMenu.Show(fileView, e.Location);
                }
            }
            else
            {
                emptySpaceContextMenu.Show(fileView, e.Location);
            }
        }
    }
}
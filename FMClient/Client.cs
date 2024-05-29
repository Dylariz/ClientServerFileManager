using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMClient;

public class Client
{
    private string _serverUrl;

    public Client(string serverUrl)
    {
        _serverUrl = serverUrl;
    }

    public async Task<bool> CheckServerConnection()
    {
        string scriptName = "check_connection.php";
        
        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_serverUrl}{scriptName}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<GetFilesResponseModel?> GetFiles(string path)
    {
        string scriptName = "get_folder_json.php";

        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_serverUrl}{scriptName}?path={path}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetFilesResponseModel>(responseString);
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return null;
    }
    
    public async Task CreateFolder(string path)
    {
        string scriptName = "create_folder.php";

        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_serverUrl}{scriptName}?path={path}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    public async Task DeleteObject(string path)
    {
        string scriptName = "delete_object.php";

        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_serverUrl}{scriptName}?path={path}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    public async Task UploadFile(string path, string localFilePath)
    {
        string scriptName = "upload_file.php";
        string fileName = Path.GetFileName(localFilePath);

        try
        {
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();
            using var fileStream = File.OpenRead(localFilePath);
            content.Add(new StreamContent(fileStream), "file", fileName);
            content.Add(new StringContent(path), "path");
            var response = await client.PostAsync(_serverUrl + scriptName, content);
            response.EnsureSuccessStatusCode();
            MessageBox.Show($"Файл {fileName} успешно загружен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    public async Task DownloadFile(string path, string localFilePath)
    {
        string scriptName = "download_file.php";

        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_serverUrl}{scriptName}?path={path}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var fileBytes = await response.Content.ReadAsByteArrayAsync();
                
            // Сохраняем файл на клиенте
            File.WriteAllBytes(localFilePath, fileBytes);

            MessageBox.Show($"Файл успешно загружен и сохранен как {Path.GetFileName(localFilePath)}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
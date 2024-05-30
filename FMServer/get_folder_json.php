<?php
function read_files_and_folders($path) {
    $result = array();

    // Добавляем к пути ServerData
    $path = 'ServerData' . DIRECTORY_SEPARATOR . trim($path, '/'); 
    
    // Проверяем существование пути
    if (!file_exists($path)) {
        http_response_code(404); // Устанавливаем код 404 Not Found
        echo "404 Not Found: Путь не найден: $path";
        return;
    }

    // Получаем список файлов и папок
    $files = scandir($path);

    // Перебираем список файлов и папок и формируем массив
    foreach ($files as $file) {
        if ($file !== '.' && $file !== '..') {
            $fullPath = $path . DIRECTORY_SEPARATOR . $file;
            $type = is_dir($fullPath) ? "Папка" : "Файл";
            $timestamp = date("d.m.o G:i", filemtime($fullPath));
            $sizeString = is_file($fullPath) ? format_bytes(filesize($fullPath)) : null;

            $result[] = array(
                'name' => $file,
                'type' => $type,
                'timestamp' => $timestamp,
                'size' => $sizeString
            );
        }
    }

    return $result;
}

// Функция для форматирования размера файла
function format_bytes($bytes) {
    $units = array('Б', 'КБ', 'МБ', 'ГБ', 'ТБ');
    $index = 0;

    while ($bytes >= 1024 && $index < count($units) - 1) {
        $bytes /= 1024;
        $index++;
    }

    return round($bytes, 2) . ' ' . $units[$index];
}

// Пример: http://localhost:3000/get_folder_json.php?path=/test1/
if (!isset($_GET['path'])) {
    http_response_code(400); // Устанавливаем код 400 Bad Request
    echo "400 Bad Request: Не указан путь для чтения";
    return;
}
$pathToRead = $_GET['path']; // Путь для чтения

// Проверяем выхода за пределы папки ServerData (наличие символов .. в пути)
if (strpos($pathToRead, '..') !== false) {
    http_response_code(403); // Устанавливаем код 403 Forbidden
    echo "403 Forbidden: Запрещено использовать символы .. в пути";
    return;
}

$result = read_files_and_folders($pathToRead);

// Формируем ответ
$response = array(
    'path' => '/' . trim($pathToRead, '/'),
    'count' => count($result),
    'objects' => $result
);

// Отправляем ответ
header('Content-Type: application/json');
echo json_encode($response, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
?>

<?php
function download_file($path) {
    // Добавляем к пути ServerData
    $fullPath = 'ServerData' . DIRECTORY_SEPARATOR . trim($path, '/'); 
    
    // Проверяем существование файла
    if (!file_exists($fullPath)) {
        http_response_code(404); // Устанавливаем код 404 Not Found: Файл не найден
        return;
    }

    // Отправляем файл клиенту
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename="' . basename($fullPath) . '"');
    readfile($fullPath);
}

// Пример использования: http://localhost:3000/Server/download_file.php?path=/test1/myfile.txt
if (!isset($_GET['path'])) {
    http_response_code(400); // Устанавливаем код 400 Bad Request: Не указан путь для загрузки
    return;
}

$pathToDownload = $_GET['path']; // Путь для загрузки файла

// Проверяем выхода за пределы папки ServerData (наличие символов .. в пути)
if (strpos($pathToDownload, '..') !== false) {
    http_response_code(403); // Устанавливаем код 403 Forbidden: Запрещено использовать символы .. в пути
    return;
}

download_file($pathToDownload);
?>

<?php
function upload_file($path, $fileData) {
    // Добавляем к пути ServerData
    $fullPath = 'ServerData' . DIRECTORY_SEPARATOR . trim($path, '/'); 

    // Проверяем существование пути
    if (!file_exists($fullPath)) {
        http_response_code(404); // Устанавливаем код 404 Not Found
        echo "404 Not Found: Папка не существует: $path";
        return false;
    }

    // Загружаем файл
    $fileName = basename($fileData['name']);
    $targetPath = $fullPath . DIRECTORY_SEPARATOR . $fileName;

    if (move_uploaded_file($fileData['tmp_name'], $targetPath)) {
        http_response_code(200); // Устанавливаем код 200 OK
        echo "200 OK: Файл успешно загружен: $fileName";
        return true;
    } else {
        http_response_code(500); // Устанавливаем код 500 Internal Server Error
        echo "500 Internal Server Error: Ошибка при загрузке файла: $fileName";
        return false;
    }
}

// Пример использования: Начать потоковую загрузку на http://localhost:3000/upload_file.php
if (!isset($_POST['path'])) {
    http_response_code(400); // Устанавливаем код 400 Bad Request
    echo "400 Bad Request: Не указан путь для загрузки";
    return;
}

if (!isset($_FILES['file'])) {
    http_response_code(400); // Устанавливаем код 400 Bad Request
    echo "400 Bad Request: Не указан файл для загрузки";
    return;
}

$pathToUpload = $_POST['path']; // Путь для загрузки файла
$fileData = $_FILES['file']; // Данные о загружаемом файле
$fullPath = 'ServerData' . DIRECTORY_SEPARATOR . trim($pathToUpload, '/');

// Проверяем существование файла
if (file_exists($fullPath . DIRECTORY_SEPARATOR . $fileData['name'])) {
    http_response_code(409); // Устанавливаем код 409 Conflict
    echo "409 Conflict: Файл уже существует: $fileData[name]";
    return;
}

// Проверяем выхода за пределы папки ServerData (наличие символов .. в пути)
if (strpos($pathToUpload, '..') !== false) {
    http_response_code(403); // Устанавливаем код 403 Forbidden
    echo "403 Forbidden: Запрещено использовать символы .. в пути";
    return;
}

// Проверяем существование папки
if(!file_exists($fullPath)){
    include 'create_folder.php';
    create_folder($pathToUpload); // Вызываем функцию создания папки из файла create_folder.php
}

upload_file($pathToUpload, $fileData);
?>
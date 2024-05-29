<?php
function create_folder($path) {
    // Добавляем к пути ServerData
    $fullPath = 'ServerData' . DIRECTORY_SEPARATOR . trim($path, '/'); 
    
    // Проверяем существование пути
    if (file_exists($fullPath)) {
        http_response_code(409); // Устанавливаем код 409 Conflict
        echo "409 Conflict: Папка уже существует: $path";
        return;
    }

    // Создаем папку
    if (mkdir($fullPath, 0777, true)) {
        http_response_code(201); // Устанавливаем код 201 Created
        echo "201 Created: Папка успешно создана: $path";
    } else {
        http_response_code(500); // Устанавливаем код 500 Internal Server Error
        echo "500 Internal Server Error: Ошибка при создании папки: $path";
    }
}

// Пример использования: http://localhost:3000/Server/create_folder.php?path=/test1/new_folder/
if (!isset($_GET['path'])) {
    http_response_code(400); // Устанавливаем код 400 Bad Request
    echo "400 Bad Request: Не указан путь для создания";
    return;
}
$pathToCreate = $_GET['path']; // Путь для создания

// Проверяем выхода за пределы папки ServerData (наличие символов .. в пути)
if (strpos($pathToCreate, '..') !== false) {
    http_response_code(403); // Устанавливаем код 403 Forbidden
    echo "403 Forbidden: Запрещено использовать символы .. в пути";
    return;
}

create_folder($pathToCreate);
?>

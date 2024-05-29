<?php
function delete_file_or_folder($path) {
    // Добавляем к пути ServerData
    $fullPath = 'ServerData' . DIRECTORY_SEPARATOR . trim($path, '/'); 
    
    // Проверяем существование файла или папки
    if (!file_exists($fullPath)) {
        http_response_code(404); // Устанавливаем код 404 Not Found
        echo "404 Not Found: Файл или папка не найдены: $path";
        return;
    }

    // Запрещаем удалять корневую папку
    if ($fullPath === 'ServerData' . DIRECTORY_SEPARATOR) {
        http_response_code(403); // Устанавливаем код 403 Forbidden
        echo "403 Forbidden: Запрещено удалять корневую папку";
        return;
    }

    // Удаляем файл или папку
    if (is_dir($fullPath)) {
        // Рекурсивно удаляем папку
        if (recoursive_delete($fullPath)) {
            http_response_code(200); // Устанавливаем код 200 OK
            echo "200 OK: Папка успешно удалена: $path";
        } else {
            http_response_code(500); // Устанавливаем код 500 Internal Server Error
            echo "500 Internal Server Error: Ошибка при удалении папки: $path";
        }
    } else {
        // Удаляем файл
        if (unlink($fullPath)) {
            http_response_code(200); // Устанавливаем код 200 OK
            echo "200 OK: Файл успешно удален: $path";
        } else {
            http_response_code(500); // Устанавливаем код 500 Internal Server Error
            echo "500 Internal Server Error: Ошибка при удалении файла: $path";
        }
    }
}

function recoursive_delete($path) {
    $files = array_diff(scandir($path), array('.', '..'));
    foreach ($files as $file) {
        (is_dir("$path/$file")) ? recoursive_delete("$path/$file") : unlink("$path/$file");
    }
    return rmdir($path);
}

// Пример использования: http://localhost:3000/Server/delete_object.php?path=/test1/
if (!isset($_GET['path'])) {
    http_response_code(400); // Устанавливаем код 400 Bad Request
    echo "Не указан путь для удаления";
    return;
}

$pathToDelete = $_GET['path']; // Путь для удаления

// Проверяем выхода за пределы папки ServerData (наличие символов .. в пути)
if (strpos($pathToDelete, '..') !== false) {
    http_response_code(403); // Устанавливаем код 403 Forbidden
    echo "Запрещено использовать символы .. в пути";
    return;
}

delete_file_or_folder($pathToDelete);
?>
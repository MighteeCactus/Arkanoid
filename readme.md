# Arkanoid Game Example

## Тестовое задание.
[![Gameplay example](https://github.com/MighteeCactus/Arkanoid/tree/main/Media/gameplay.mp4)](https://github.com/MighteeCactus/Arkanoid/tree/main/Media/gameplay.jpg)

## Описание
- Все объекты в сцене сделаны с прицелом на использование интерфейсов;
- Там, где необходим `MonoBehaviour`, у интерфейса есть соответствующий абстрактный класс;
- Конфигурация игры по максимуму вынесена в отдельные `ScriptableObject`'ы;
- Фреймворка Dependency Injection контейнера в проекте нет, но несколько классов "притворяются" что есть, чтобы получить зависимость `EventDispatcher`.
﻿# 🚀 SpaceSorties – Простой анализатор твоих дисков

Купил себе ЭВМ на Core i3 6100 и GTX 970? Скачал любимые Dota 2 и Smite?
Вроде как диск у тебя на 1 терабайт, а доступно осталось меньше 100 гигов.
Да и за компом максимум маман в Excel работает, не будет же он терабайт занимать.

Найди в недрах мусор твоего накопителя поможет программа **«Пространственные сортировки»**.

## 🤔 О программе

Цель программы просканировать Ваши диски и показать их в удобном виде, в виде дерева.

### 🖼️ Интерфейс программы
![Интерфейс программы](https://github.com/nickstrlnkv/SpaceSorties/raw/main/interface.png)

## ❗ Примечание от автора
Программа во время своей работы может просканировать не все доступные папки.
Такие папки, как «$RECYCLE.BIN», «System Volume Information», «Boot» и так далее, будут пропущены.
Если вы хотите, чтобы эти директории участвовали в сканировании, то запустите программу
от имени администратора. НО ДЕЛАЙТЕ ЭТО НА СВОЙ СТРАХ И РИСК. Автор не несёт ответственность,
если в ходе работы программы эти директории будут повреждены!

## 🔔 Как установить?
- Актуальную версию можешь найти [здесь](https://github.com/nickstrlnkv/SpaceSorties/releases).

## ✅ TODO
- Написать функционал для сканирования только выбранного диска
- Добавить прогрессбар сканирования
- Добавить многопоточность, чтобы программа не зависала с жирными дисками.
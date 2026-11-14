# Git Advanced Notes (Level 3)

## Задание 46: Git Stash
- **git stash list до:**
  *(пусто)*

- **git stash list после git stash:**
  `stash@{0}: WIP on level-3: ...`

- **git stash list после git stash pop:**
  *(пусто, изменения восстановлены)*

  ## Задание 47: Git Rebase Interactive (Squash)
- **git log --oneline до ребейза:**
  (Список из 4 мелких коммитов)

- **git log --oneline после ребейза (squash):**
  (Все 4 коммита успешно объединены в один аккуратный коммит)

  ## Задание 48: Git Tags (v1.0.0)
- **git tag:**
  `v1.0.0`

- **git show v1.0.0:**
  ```text
  tag v1.0.0
  Tagger: ...
  Date:   ...

  Release v1.0.0

  ## Задание 49: Git Reflog Recovery
- **git reflog (фрагмент):**
  `<hash> HEAD@{0}: reset: moving to ...`
  `<hash> HEAD@{1}: commit: temp: коммит для удаления`

- **git log --oneline после восстановления:**
  (Коммит успешно возвращен в историю репозитория)
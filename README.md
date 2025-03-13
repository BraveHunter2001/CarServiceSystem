# CarServiceSystem
Инструкция для бека:  
1. выполнить `docker compose up`, для того-чтобы развернуть контейнер с БД MS SQl.
2. Применить миграции, чтобы создать таблицы, и заполнить их данными:  
`dotnet ef --project DAL database update  --context CarServiceSystemContext --startup-project WebApi`
4. Запуск бека попрофилю `http` через визуалку

Инструкция для фронта:  
1. перейти в директорию `carclient`
2. Выполнить `npm install`  
3. Выполнить `npm run dev`
4. Фронт запуститься по адресу: `http://localhost:5174/`


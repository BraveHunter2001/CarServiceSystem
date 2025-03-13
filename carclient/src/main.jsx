import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import "dayjs/locale/ru";

createRoot(document.getElementById("root")).render(
  <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale="ru">
    <App />
  </LocalizationProvider>
);

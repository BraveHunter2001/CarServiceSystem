import {
  Button,
  FormControl,
  Grid2,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  Stack,
} from "@mui/material";
import { MonthCalendar } from "@mui/x-date-pickers";
import axios from "axios";
import dayjs from "dayjs";
import { useState } from "react";
import { MasterWorkLoadsTable } from "./MasterWorkLoadsTable";
import AutomobileTable from "./AutomobileTable";

const SORT_BY = {
  Brand: 0,
  LastMaster: 1,
  LastRepairDate: 2,
};

const SORT_DIR = {
  Asc: 0,
  Dsc: 1,
};

const initDate = dayjs().month(4).date(1);
const BACKEND_URL = "http://localhost:5134/api/";

function App() {
  const [currentMonth, setMonth] = useState(initDate);
  const [masterWorloads, setMasterWorloads] = useState();
  const [automibiles, setAutomibiles] = useState();

  const [sortBy, setSortBy] = useState(SORT_BY.Brand);
  const [sortDir, setSortDir] = useState(SORT_DIR.Asc);

  const handleGetReport = async () => {
    const daysOfMounth = currentMonth.daysInMonth();
    const end = currentMonth.date(daysOfMounth);

    try {
      const response = await axios.get(BACKEND_URL + "Reports", {
        params: {
          start: currentMonth.format(),
          end: end.format(),
          sortBy: sortBy,
          sortDir: sortDir,
        },
      });

      setMasterWorloads(response.data.mastersWorkLoads);
      setAutomibiles(response.data.autos);
    } catch (error) {
      console.error("Ошибка запроса:", error);
    }
  };
  return (
    <Grid2 container spacing={2}>
      <Grid2 size={3} container>
        <Grid2 size={12}>
          <MonthCalendar
            value={currentMonth}
            onChange={(newValue) => setMonth(newValue)}
          />
        </Grid2>
        <Grid2 size={6}>
          <FormControl variant="standard" sx={{ minWidth: 120 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Сортировать по
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={sortBy}
              onChange={(event) => setSortBy(event.target.value)}
              label="Сортировать"
            >
              <MenuItem value={SORT_BY.Brand}>Марке</MenuItem>
              <MenuItem value={SORT_BY.LastMaster}>Фио мастера</MenuItem>
              <MenuItem value={SORT_BY.LastRepairDate}>Дате ремота</MenuItem>
            </Select>
          </FormControl>
        </Grid2>
        <Grid2 size={6}>
          <FormControl variant="standard" sx={{ minWidth: 120 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Направление
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={sortDir}
              onChange={(event) => setSortDir(event.target.value)}
              label="Сортировать"
            >
              <MenuItem value={SORT_DIR.Asc}>Возрастанию</MenuItem>
              <MenuItem value={SORT_DIR.Dsc}>Убыванию</MenuItem>
            </Select>
          </FormControl>
        </Grid2>
        <Grid2 size={12}>
          <Button variant="contained" onClick={handleGetReport}>
            Получить отчет по машинам
          </Button>
        </Grid2>
      </Grid2>
      <Grid2 size={9}>
        {masterWorloads && <MasterWorkLoadsTable workloads={masterWorloads} />}
      </Grid2>
      <Grid2 size={12}>
        {automibiles && <AutomobileTable automibiles={automibiles} />}
      </Grid2>
    </Grid2>
  );
}

export default App;

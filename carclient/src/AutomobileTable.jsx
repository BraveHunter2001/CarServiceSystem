import {
  Box,
  Collapse,
  IconButton,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import { useState } from "react";

const DetailRow = ({ row, index }) => {
  const [open, setOpen] = useState(false);

  return (
    <>
      <TableRow sx={{ "& > *": { borderBottom: "unset" } }}>
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell>{row.brand}</TableCell>
        <TableCell align="right">{row.model}</TableCell>
        <TableCell align="right">{row.licensePlate}</TableCell>
        <TableCell align="right">{row.mileage}</TableCell>
        <TableCell align="right">{row.engineVolume}</TableCell>
        <TableCell align="right">{row.lastRepairWorkRecordDate}</TableCell>
        <TableCell align="right">{row.lastMaster}</TableCell>
        <TableCell align="right">{row.allWorkPrice}</TableCell>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                Детализация стоимости по мастерам
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>Мастер</TableCell>
                    <TableCell>Цена</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row.masterCostItems.map((item, itemIndex) => (
                    <TableRow key={itemIndex}>
                      <TableCell component="th" scope="row">
                        {item.fullname}
                      </TableCell>
                      <TableCell align="right">{item.cost}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </>
  );
};

const AutomobileTable = ({ automibiles }) => {
  return (
    <TableContainer component={Paper} sx={{ minWidth: 650 }}>
      <Table aria-label="Автомобили">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Марка</TableCell>
            <TableCell align="right">Модель</TableCell>
            <TableCell align="right">Гос. номер</TableCell>
            <TableCell align="right">Пробег</TableCell>
            <TableCell align="right">Объем</TableCell>
            <TableCell align="right">Дата посл. ремонта</TableCell>
            <TableCell align="right">Посл. мастер</TableCell>
            <TableCell align="right">Полная стоимость ремонта</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {automibiles.map((row, index) => (
            <DetailRow row={row} key={index} />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default AutomobileTable;

import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";

export const MasterWorkLoadsTable = ({ workloads }) => {
  return (
    <TableContainer component={Paper} sx={{ minWidth: 650 }}>
      <Table aria-label="Загруженность рабочих">
        <TableHead>
          <TableRow>
            <TableCell>ФИО</TableCell>
            <TableCell align="right">Процент загруженности, %</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {workloads.map((row, index) => (
            <TableRow
              key={index}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.fullnameMaster}
              </TableCell>
              <TableCell align="right">{row.workloadPercentage}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

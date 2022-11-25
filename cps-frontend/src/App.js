import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import './App.css';
import { getOrders, uploadFile } from './api/orders';
import Button from '@mui/material/Button';

function App() {

  const [orders, setOrders] = useState([]);
  const [isVisible, setIsVisible] = useState(true);

  useEffect(() => {
		setOrdersAsync().catch(console.error);
	}, [orders])

  const setOrdersAsync = async () => {
    var orders = await getOrders();
		setOrders(orders);
	}

  const onFileUploaded = (event) => {
    event.preventDefault();
    var file = event.target.files[0];
    var formData = new FormData();
    formData.append("orders", file);
    uploadFile(formData);
    setOrdersAsync();
  }

  const print = (event) => {
    event.preventDefault();
    setIsVisible(false);
    setTimeout(() => {
      window.print();
      setIsVisible(true);
    },1000)
  }

  const onPrintChange = (event) => {
    debugger;
    setIsVisible(true);
  }

  return (
    <div className="App">
      {isVisible ? <header>CSP App</header> : null}
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Date Required</TableCell>
                <TableCell align="center">Size</TableCell>
                <TableCell align="center">Notes</TableCell>
                <TableCell align="center">Quantity</TableCell>
                <TableCell align="center">CustomerEmail</TableCell>
                <TableCell align="center">CustomerName</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {orders.map((row) => (
                <TableRow
                  key={row.name}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                        {row.DateRequired}
                  </TableCell>
                  <TableCell align="center">{row.Size}</TableCell>
                  <TableCell align="center">{row.Notes}</TableCell>
                  <TableCell align="center">{row.Quantity}</TableCell>
                  <TableCell align="center">{row.CustomerEmail}</TableCell>
                  <TableCell align="center">{row.CustomerName}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        {isVisible ? <Button variant="contained" component="label" onChange={onFileUploaded}> Upload File
              <input type="file" hidden/>
        </Button> : null}
        
        {isVisible ? <Button variant="contained" component="label" onClick={print} onChange={onPrintChange}> Print
        </Button> : null}
        
    </div>
  );
}

export default App;

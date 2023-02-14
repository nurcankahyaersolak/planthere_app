// React 
import React, { useState } from 'react';

// Metarial UI

import { Card, CardContent } from '@mui/material';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';

import Box from '@mui/material/Box';
import Collapse from '@mui/material/Collapse';
import Grid from '@mui/material/Grid';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Tooltip from '@mui/material/Tooltip';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import Cointeiner from '@mui/material/Container'
import Link from '@mui/material/Link'

// Icon 
import InfoIcon from '@mui/icons-material/Info';

//Custom Hooks
import useFetch from '../../hooks/useFetch';

function Row(props) {
    const { row } = props;
    const [open, setOpen] = useState(false);
    return (
        <React.Fragment>
            <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
                <TableCell>
                    <IconButton
                        aria-label="expand row"
                        size="small"
                        onClick={() => setOpen(!open)}
                    >
                        {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
                    </IconButton>

                </TableCell>
                <TableCell component="th" scope="row">
                    {row.createdDate.slice(0, 10)}
                </TableCell>
                <TableCell align="right">{row.totalPrice}</TableCell>
                <TableCell align="right">{row.discountedTotalPrice}</TableCell>
                <TableCell align="right">{row.address.province}/{row.address.district}&nbsp;{row.address.street}&nbsp;{row.address.line}&nbsp;{row.address.zipCode}</TableCell>
            </TableRow>
            <TableRow>
                <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
                    <Collapse in={open} timeout="auto" unmountOnExit>
                        <Box sx={{ margin: 1 }}>
                            <Typography variant="h6" gutterBottom component="div">
                                Order Detail
                            </Typography>
                            <Table size="small" aria-label="purchases">
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Product Id</TableCell>
                                        <TableCell>Info</TableCell>
                                        <TableCell>Product Name</TableCell>
                                        <TableCell align="right">Price ($) </TableCell>
                                        <TableCell align="right">Discounted Price ($)</TableCell>
                                        <TableCell>Count</TableCell>
                                        <TableCell align="right"> Total Price ($) </TableCell>
                                        <TableCell align="right"> Total Discounted Price ($)</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {row.orderItems.map((orderItemsRow) => (
                                        <TableRow key={orderItemsRow.productId}>
                                            <TableCell>{orderItemsRow.productId}</TableCell>
                                            <TableCell align="right">
                                                <Tooltip title="Detail">
                                                    <Link sx={{ ml: 5 }} target="_blank" href={`/details/${orderItemsRow.productId}`} rel="noopener">
                                                        <IconButton size="medium" color="primary" variant="filledTonal" >
                                                            <InfoIcon></InfoIcon>
                                                        </IconButton>
                                                    </Link>
                                                </Tooltip>
                                            </TableCell>
                                            <TableCell component="th" scope="row">
                                                {orderItemsRow.productName}
                                            </TableCell>
                                            <TableCell>{orderItemsRow.price}</TableCell>
                                            <TableCell align="right">{orderItemsRow.discountedPrice}</TableCell>
                                            <TableCell align="right">{orderItemsRow.count}</TableCell>
                                            <TableCell align="right">
                                                {orderItemsRow.price * orderItemsRow.count}
                                            </TableCell>
                                            <TableCell align="right">
                                                {orderItemsRow.price * orderItemsRow.count}
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </Box>
                    </Collapse>
                </TableCell>
            </TableRow>
        </React.Fragment>
    );
}

export default function Order() {
    
    const [data] = useFetch('/orders')

    return (<Cointeiner sx={{ mt: 12, p: 1 }} direction="row">
        <Card>
            <CardContent>
                <Grid>
                    <TableContainer component={Paper}>
                        <Table aria-label="collapsible table">
                            <TableHead>
                                <TableRow>
                                    <TableCell />
                                    <TableCell>Created Date</TableCell>
                                    <TableCell align="right">Order Total Price ($) </TableCell>
                                    <TableCell align="right">Order Total Discounted Price ($)</TableCell>
                                    <TableCell align="right">Address</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {data?.map((row) => (
                                    <Row key={row.id} row={row} />
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </CardContent>
        </Card>

    </Cointeiner>);
}
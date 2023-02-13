//React 
import React, { useState, useEffect } from 'react';

// Mererial UI
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';

const PaymentForm = (props) => {

  const [payment, setPayment] = useState({})

  useEffect(() => {
    props.setvaluePaymentChild(payment);
  }, [payment,props]);

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Payment method
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12} md={6}>
          <TextField
            required
            id="cardHolderName"
            label="Card Holder Name"
            fullWidth
            variant="standard"
            onChange={(cardHolderName) => setPayment(prev => ({ ...prev, cardHolderName: cardHolderName.target.value }))}
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <TextField
            required
            id="cardNumber"
            label="Card number"
            fullWidth
            variant="standard"
            onChange={(cardNumber) => setPayment(prev => ({ ...prev, cardNumber: cardNumber.target.value }))}
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <TextField
            required
            id="cardSecurityNumber"
            label="Card Security Number"
            fullWidth
            helperText="Last three digits on signature strip"
            autoComplete="cc-exp"
            variant="standard"
            onChange={(cardSecurityNumber) => setPayment(prev => ({ ...prev, cardSecurityNumber: cardSecurityNumber.target.value }))}
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <TextField
            required
            type="number"
            id="cardTypeId"
            label="Card Expiration Year"
            fullWidth
            variant="standard"
            onChange={(cardTypeId) => setPayment(prev => ({ ...prev, cardTypeId: parseInt(cardTypeId.target.value) }))}
          />
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default PaymentForm
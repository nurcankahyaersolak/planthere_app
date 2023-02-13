// React 
import React, { useState, useEffect } from 'react';

// Meterial UI
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';

const AddressForm = (props) => {
  const [address, setAddress] =  useState({})

  useEffect(() => {
    props.setvalueAddressChild(address);
  }, [address,props]);

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Shipping address
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={12}>
          <TextField
            required
            id="province"
            name="Province"
            label="Province"
            fullWidth
            variant="standard"
            onChange={(province)=> setAddress(prev => ({ ...prev, province: province.target.value }))}
          />
        </Grid>
        <Grid item xs={12} sm={12}>
          <TextField
            required
            id="district"
            name="district"
            label="District"
            fullWidth
            variant="standard"
            onChange={(district)=> setAddress(prev => ({ ...prev, district: district.target.value }))}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            required
            id="street"
            name="street"
            label="Street"
            fullWidth
            variant="standard"
            onChange={(street)=> setAddress(prev => ({ ...prev, street: street.target.value }))}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            id="zipCode"
            name="zipCode"
            label="Zip Code"
            fullWidth
            variant="standard"
            onChange={(zipCode)=> setAddress(prev => ({ ...prev, zipCode: zipCode.target.value }))}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            required
            id="line"
            name="line"
            label="Line"
            fullWidth
            autoComplete="shipping postal-code"
            variant="standard"
            onChange={(line)=> setAddress(prev => ({ ...prev, line: line.target.value }))}
          />
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default AddressForm
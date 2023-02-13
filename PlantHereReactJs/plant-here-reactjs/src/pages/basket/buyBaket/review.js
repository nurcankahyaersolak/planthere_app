//React
import React from 'react';

//Redux
import { useSelector } from 'react-redux';

//Metarial UI
import Typography from '@mui/material/Typography';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Grid from '@mui/material/Grid';
import { Stack } from '@mui/system';

const Review = (props) => {

  // Redux Store
  
  const { basket } = useSelector(state => state.basket)
  const { user } = useSelector(state => state.user)
  const basketItems = basket?.basketItems

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Order summary
      </Typography>
      <List disablePadding>
        {basketItems.map((basketItem) => (
          <ListItem key={basketItem.id} sx={{ py: 1, px: 0 }}>
            <ListItemText primary={basketItem.productName} secondary={basketItem.count} />
            {basketItem.price !== basketItem.discountedPrice ? <Grid>
              <Typography variant="body2" color="red" sx={{ textDecoration: "line-through" }}>
                {basketItem.price}$
              </Typography>
              <Typography variant="body2">{basketItem.discountedPrice}$</Typography>
            </Grid> :
              <Typography variant="body2">{basketItem.price}$</Typography>
            }
          </ListItem>
        ))}

        <ListItem sx={{ py: 1, px: 0 }}>
          {(basket !== null) && <Grid item sx={{ p: 1 }} container direction="row"
            justifyContent="right"
            alignItems="right" >
            {basket.totalPrice !== basket.discountedTotalPrice ? <Stack>
              <Stack direction="row" sx={{ mb: 2 }}>
                <Typography variant="body2" color="text.secondary">
                  Total Price :&nbsp;
                </Typography>
                <Typography variant="body2" color="red" sx={{ textDecoration: "line-through" }}>
                  {basket.totalPrice} $
                </Typography>
              </Stack>
              <Typography variant="body2" color="text.secondary">
                Total Discounted Price : {basket.discountedTotalPrice} $
              </Typography>
            </Stack>
              :
              <Typography variant="body2" color="text.secondary">
                Total Price : {basket.totalPrice} $
              </Typography>
            }  </Grid>}
        </ListItem>
      </List>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6}>
          <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
            Shipping
          </Typography>
          <Grid container>
            <Grid item xs={12}>
              <Typography gutterBottom>{user.userName}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.address.province}/{props.address.district}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.address.street}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.address.line}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.address.zipCode}</Typography>
            </Grid>
          </Grid>
        </Grid>
        <Grid item container direction="column" xs={12} sm={6}>
          <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
            Payment details
          </Typography>
          <Grid container>
            <Grid item xs={12}>
              <Typography gutterBottom>{props.payment.cardNumber}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.payment.cardSecurityNumber}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.payment.cardTypeId}</Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography gutterBottom>{props.payment.cardHolderName}</Typography>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default Review
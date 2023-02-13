//React 
import React, { useRef } from 'react';
import { useNavigate } from "react-router-dom";

// Metarial IU
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Link from '@mui/material/Link'

// Icon
import LocalGroceryStoreIcon from '@mui/icons-material/LocalGroceryStore';
import AddIcon from '@mui/icons-material/Add';

// Notification
import Notification from '../../services/notificationService'

// Axios Instance
import { useAxiosPrivateDotNet, useAxiosPrivateNodejs } from '../../hooks/useAxiosPrivatePlantHere';

// Redux
import { useSelector, useDispatch } from 'react-redux';

// Basket Actions
import { FetchBasket } from '../../redux/actions/basketActions';

export default function ProductCard(props) {

  //Hooks
  const navigate = useNavigate();
  const dispatch = useDispatch();

  //Redux State
  const { isSelectedDotnetApi } = useSelector(state => state.api)
  const { auth } = useSelector(state => state.user)
  
  // Axios Instance
  const notificationRef = useRef();
  const axiosPrivateDotNet = useAxiosPrivateDotNet(notificationRef)
  const axiosPrivateNodeJs = useAxiosPrivateNodejs(notificationRef)

  //#region Button Event

  const addBasket = async () => {

    if (!auth) {
      navigate('/SignIn')
    }

    const body = {
      productId: props.uniqueId,
      productName: `${props.name}(${props.description})`,
      price: props.price,
      discountedPrice: props.discountedPrice
    }

    if (isSelectedDotnetApi) {
      await axiosPrivateDotNet.post('/BasketItem', body)
      dispatch(FetchBasket(axiosPrivateDotNet))
    }
    else {
      await axiosPrivateNodeJs.post('/BasketItem', body)
      dispatch(FetchBasket(axiosPrivateNodeJs))
    }
  }

  const gotoBasket = () => {
    if (!auth) {
      navigate('/SignIn')
    }
    else {
      navigate('/Basket')
    }
  }

  //#endregion

  return (
    <React.Fragment>
      <Notification ref={notificationRef}></Notification>
      <Card sx={{ maxWidth: 400, margin: 1 }} >
        <CardMedia
          component="img"
          alt={props.name}
          height="190"
          image={props.image}
        />
        <CardContent sx={{ width: 300, height: 120 }}>
          <Typography gutterBottom variant="h5" component="div">
            {props.name}
          </Typography>
          <Typography mb={2} variant="body2" color="text.secondary">
            {props.description}
          </Typography>

          {props.price !== props.discountedPrice ? <React.Fragment>
            <Typography variant="body2" color="red" sx={{ textDecoration: "line-through" }}>
              {props.price} $
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {props.discountedPrice} $
            </Typography>
          </React.Fragment>
            :
            <Typography variant="body2" color="text.secondary">
              {props.price} $
            </Typography>
          }
        </CardContent>
        <CardActions  >
          <Button size="small" onClick={addBasket} ><AddIcon fontSize="small"></AddIcon> Add To Basket</Button>
          <Button size="small" onClick={gotoBasket} ><LocalGroceryStoreIcon fontSize="small"></LocalGroceryStoreIcon>Basket</Button>
          <Link sx={{ ml: 5 }} target="_blank" href={`/details/${props.uniqueId}`} rel="noopener"><Button size="small">Detail</Button></Link>
        </CardActions>
      </Card>
    </React.Fragment>
  );
}
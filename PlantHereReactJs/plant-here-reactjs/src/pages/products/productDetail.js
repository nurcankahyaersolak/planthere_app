// React 
import React, { useEffect, useState, useRef } from 'react';
import { useParams, useNavigate } from 'react-router';

//Redux
import { useSelector, useDispatch } from 'react-redux';

//Redux Action
import { FetchBasket } from '../../redux/actions/basketActions';

//Axios Instans
import { GetSelectedAxios, useAxiosPrivateDotNet, useAxiosPrivateNodejs } from '../../hooks/useAxiosPrivatePlantHere';

//Merarial IU
import Grid from '@mui/material/Grid';
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';
import Container from '@mui/material/Container';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Card from '@mui/material/Card';

//Icon
import LocalGroceryStoreIcon from '@mui/icons-material/LocalGroceryStore';
import AddIcon from '@mui/icons-material/Add';


// Notification
import Notification from '../../services/notificationService'

const ProductDetail = () => {
    const params = useParams();
    const [product, setProduct] = useState({
        images: []
    })

    //Hooks
    const navigate = useNavigate();
    const dispatch = useDispatch();
    
    //Redux State
    const { auth } = useSelector(state => state.user)
    const { isSelectedDotnetApi } = useSelector(state => state.api)
    
    // Axios Instance
    const notificationRef = useRef();
    const axiosPrivateDotNet = useAxiosPrivateDotNet(notificationRef)
    const axiosPrivateNodeJs = useAxiosPrivateNodejs(notificationRef)
    const axiosPrivate = GetSelectedAxios(isSelectedDotnetApi)()

    useEffect(() => {
        const fetchDataProduct = async () => {
            const response = await axiosPrivate.get(`/Product/${params.id}`)
            return response.data.data
        }
        fetchDataProduct().then(data => {
            if (data) {
                setProduct(data)
            }
            else {
                navigate('/NotFound')
            }
        }).catch(console.error)
    }, [params.id, navigate,axiosPrivate])

    const addBasket = async () => {

        if (!auth) {
            navigate('/SignIn')
        }

        const body = {
            productId: product.uniqueId,
            productName: `${product.name}(${product.description})`,
            price: product.price,
            discountedPrice: product.discountedPrice
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

    return (
        <Container fixed sx={{ mt: 12 }} >
            <Notification ref={notificationRef}></Notification>
            <Grid>
                <Card>
                    <CardContent >
                        <ImageList sx={{ height: 300 }} cols={4} >
                            {product.images.map((item) => (
                                <ImageListItem key={item.url}>
                                    <img
                                        src={`${item.url}?w=250&h=250&fit=crop&auto=format`}
                                        srcSet={`${item.url}?w=250&h=250&fit=crop&auto=format&dpr=2 2x`}
                                        loading="lazy"
                                        alt={`${item.url}`}
                                    />
                                </ImageListItem>
                            ))}
                        </ImageList>
                    </CardContent>
                </Card>
            </Grid>

            <Grid item sx={{ mt: 2 }} >
                <Card>
                    <CardContent>
                        <Typography sx={{ fontSize: 25 }} color="text.secondary" gutterBottom>
                            {product.name}
                        </Typography>
                        <Typography variant="h5" component="div">
                        </Typography>
                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                            {product.description}
                        </Typography>
                        <Typography variant="body2">
                            {product.care}
                        </Typography>
                        {product.price !== product.discountedPrice ? <React.Fragment >
                            <Typography variant="body2" color="red" sx={{ textDecoration: "line-through", mt: 2 }}>
                                {product.price} $
                            </Typography>
                            <Typography variant="body2" color="text.secondary" sx={{ mt: 2 }} >
                                {product.discountedPrice} $
                            </Typography>
                        </React.Fragment>
                            :
                            <Typography variant="body2" color="text.secondary" sx={{ mt: 2 }}>
                                {product.price} $
                            </Typography>
                        }

                    </CardContent>
                    <CardActions>
                        <Button size="small" onClick={addBasket} ><AddIcon fontSize="small"></AddIcon> Add To Basket</Button>
                        <Button size="small" onClick={gotoBasket}><LocalGroceryStoreIcon fontSize="small" ></LocalGroceryStoreIcon> BASKET</Button>
                    </CardActions>
                </Card>
            </Grid>
        </Container>
    )
}

export default ProductDetail;
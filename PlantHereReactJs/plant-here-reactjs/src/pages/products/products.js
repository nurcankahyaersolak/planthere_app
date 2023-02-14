//React 
import React, { useState, useEffect } from "react";

//Redux
import { useSelector } from "react-redux";

//Meterial
import ProductCard from "./productCard";
import Grid from '@mui/material/Grid';
import Container from '@mui/material/Container';
import Pagination from '@mui/material/Pagination';

//Axios Instance

import { GetSelectedAxios } from "../../hooks/useAxiosPrivatePlantHere";

const Products = () => {

    //State
    const [page, setPage] = React.useState(1);
    const [productsCount, setProductsCount] = useState(24)
    const [products, setProducts] = useState([])

    //Redux State
    const {isSelectedDotnetApi} = useSelector(state => state.api)
    
    //Axios Instance
    const axiosPrivate = GetSelectedAxios(isSelectedDotnetApi)()
    
    // Page Size 
    const pageSize = 12;

    useEffect(() => {
        const fetchProductsCount = async () => {
            const response = await axiosPrivate.get('/products/count')
            return response.data.data
        }

        const fetchDataProducts = async () => {
            const response = await axiosPrivate.get(`/products/${page}/${pageSize}`)
            return response.data.data
        }

        fetchDataProducts().then(data => {
            setProducts(data)
        }).catch(console.error)

        fetchProductsCount().then(x => setProductsCount(x.count)).catch(console.error)
        window.scrollTo(0, 0)
    }, [page,axiosPrivate]);

    const handleChange = (event, value) => {
        window.page= value
        setPage(value);
    };

    return (<React.Fragment>
        <Container fixed sx={{ mt: 10 }}  >
            <Grid container sx={{ p: 1 }} item direction="row"
                justifyContent="center"
                alignItems="center" >
                {products?.map((product, index) => (
                    <ProductCard name={product.name}
                        description={product.description}
                        image={product.images[0]?.url}
                        price={product.price}
                        discountedPrice={product.discountedPrice}
                        uniqueId={product.uniqueId}
                        key={index} />
                ))}
            </Grid>
            <Grid sx={{ p: 1 }} container item direction="row"
                justifyContent="center"
                alignItems="center">
                <Grid >
                    <Pagination count={Math.ceil(productsCount / pageSize)} page={page} onChange={handleChange} color="primary" size="large" showFirstButton showLastButton />
                </Grid>
            </Grid>
        </Container>
    </React.Fragment>)
}

export default Products
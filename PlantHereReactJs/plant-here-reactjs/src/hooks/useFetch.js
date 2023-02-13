//React
import { useState, useEffect } from "react";

// Axios Intercepters ( Instance )
import {useAxiosPrivateDotNet,GetSelectedAxios} from "./useAxiosPrivatePlantHere";

//Redux
import { useSelector } from "react-redux";

const useFetch = (url) => {
    const [data, setData] = useState([]);

    const {isSelectedDotnetApi} = useSelector(state => state.api)
    const axiosPrivate = GetSelectedAxios(isSelectedDotnetApi)()
    
    useEffect(() => {
        const fetchData = async () => {
           return  await axiosPrivate.get(url)
        }
        fetchData().then(response => {
            setData(response?.data?.data)
        })
    }, [url,axiosPrivate]);
    return [data];
};

export const useFetchForEs = (url) => {
    const [data, setData] = useState([]);
    const axiosPrivate = useAxiosPrivateDotNet()
    
    useEffect(() => {
        const fetchData = async () => {
           return  await axiosPrivate.get(url)
        }
        fetchData().then(response => {
            setData(response?.data?.data)
        })
    }, [url,axiosPrivate]);
    return [data];
};

export default useFetch;
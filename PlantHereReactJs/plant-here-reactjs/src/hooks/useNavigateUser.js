import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { SetAuthStore } from "../redux/actions/userActions";

const useNavigateUser = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const navigateUser = () => {
        setTimeout(() => {
            dispatch(SetAuthStore(false))
            navigate('/SignIn')
        }, 1500);
    }

    return navigateUser
} 

export default useNavigateUser
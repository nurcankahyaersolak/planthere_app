import React, {useImperativeHandle} from "react";
import MuiAlert from '@mui/material/Alert';
import Snackbar from '@mui/material/Snackbar';

const Alert = React.forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const Notification = React.forwardRef((props,ref) => {
    const [open, setOpen] = React.useState(false);
    const [notificationValue,setNotificationValue] = React.useState({message:"",status:"info"})

    useImperativeHandle(ref, () => ({
        handleClick(notificationValue) {
            setOpen(true);
            setNotificationValue(notificationValue)
        }
    }));

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }
        setOpen(false);
    };

    return (
        <Snackbar open={open} autoHideDuration={1500} onClose={handleClose}>
            <Alert onClose={handleClose} severity={notificationValue.status} sx={{ width: '100%' }}>
                {notificationValue.message}
            </Alert>
        </Snackbar>
    );
});

export default Notification
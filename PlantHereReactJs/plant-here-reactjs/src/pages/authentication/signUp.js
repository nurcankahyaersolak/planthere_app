// React
import React, { useRef, useState } from 'react';
import { useNavigate } from "react-router-dom";

// Material IU
import Button from '@mui/material/Button';
import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';

// Notification
import Notification from '../../services/notificationService'

// Axios Instance
import { useAxiosPrivateAuthServerWithNotification } from '../../hooks/useAxiosPrivateAuthServer';

const Copyright = (props) => {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Plant© 2023'}
    </Typography>
  );
}


const SignUp = () => {
  
  //Stete
  const [user, setUser] = useState({ userName: "", email: "", password: "" });
  
  //Hooks
  const navigate = useNavigate();
  
  //Axios Instance
  const notificationRef = useRef();
  const axiosPrivate = useAxiosPrivateAuthServerWithNotification(notificationRef);

  // On Click Event
  const handleSubmit = async (event) => {
    event.preventDefault();

    // Request 
    await axiosPrivate.post('/User', user)

    // Navigate
    setTimeout(() => {
      navigate("/SignIn");
    }, 1300);
  }

  return (
    <Container component="main" maxWidth="xs" sx={{ mt: 12 }}>
      <Notification ref={notificationRef}></Notification>
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <TextField onChange={e => setUser(prev => ({ ...prev, userName: e.target.value }))}
                required
                name="name"
                fullWidth
                id="name"
                label="Name"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField onChange={e => setUser(prev => ({ ...prev, email: e.target.value }))}
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField onChange={e => setUser(prev => ({ ...prev, password: e.target.value }))}
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="new-password"
              />
            </Grid>
          </Grid>
          <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
            Sign Up
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link href="Signin" variant="body2">
                Already have an account? Sign in
              </Link>
            </Grid>
          </Grid>
        </Box >
      </Box>
      <Copyright sx={{ mt: 5 }} />
    </Container>
  );
}

export default SignUp
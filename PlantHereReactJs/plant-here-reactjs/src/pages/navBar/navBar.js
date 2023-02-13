// React
import React from 'react';
import { Link as RouterLink } from 'react-router-dom';

// Metarial IU
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import ForestRoundedIcon from '@mui/icons-material/ForestRounded';

// Component 
import { ToolBarButton } from './toolBarButton'
import { ToolBarSwitch } from './toolBarSwitch'

function ResponsiveAppBar() {
  return (
    <AppBar fixed='top'>
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <ToolBarSwitch></ToolBarSwitch>
          <ForestRoundedIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} />
          <Typography
            component={RouterLink} to="/"
            variant="h6"
            noWrap
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 800,
              letterSpacing: '.2rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            Plant Here
          </Typography>
          <Typography
            variant="h5"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            Plant Here
          </Typography>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' } }}
          >
          </Typography>
          <Box sx={{ flexGrow: 0 }}>
            <ToolBarButton />
          </Box>
        </Toolbar>
      </Container>
    </AppBar >
  );
}

export default ResponsiveAppBar;
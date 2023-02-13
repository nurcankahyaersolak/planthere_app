//React
import React from 'react';

//Redux
import { useDispatch, useSelector } from 'react-redux';

// Metarial UI
import { Stack } from '@mui/system';
import Switch from '@mui/material/Switch';
import Typography from '@mui/material/Typography';

//Redux Action
import { SetSelectedApi} from '../../redux/actions/apiActions';

export const ToolBarSwitch = () => {

    const Dispach = useDispatch();

    const{isSelectedDotnetApi} = useSelector(state => state.api)

    const handleChange = () => {
        Dispach(SetSelectedApi(!isSelectedDotnetApi))
    };
    return (
        <Stack direction="row" alignItems="center" sx={{ m: 3 }}>
            <Typography variant="caption">Node.js</Typography>
            <Switch color="secondary" checked={isSelectedDotnetApi} onChange={handleChange} />
            <Typography variant="caption">.Net</Typography>
        </Stack>
    )
} 
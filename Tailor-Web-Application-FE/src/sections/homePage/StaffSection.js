/* eslint-disable array-callback-return */
/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';
import { FormattedMessage } from 'react-intl';

import { StaffCard } from '../../components';
import shape1 from "../../assets/shape-1.png";
import staffMember from "../../assets/StaffMember.jpg";
import tailorList from '../../_mock/tailorList';

const StafFSection = () => {

    
    return (   
        <Box sx = {{
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
            width : '100%',
            height: '650px',
            bgcolor: 'white',
            py: '30px',
        }}>  
          <img src = {shape1} alt = "" width = "60px"/>
        <Typography sx =  {{fontSize: '35px'}}> <FormattedMessage id="lbl.meetTheTailors.home"/> </Typography>
        <Box sx  ={{
            display:'flex',
            alignItems: 'center',
            justifyContent: 'center',
            flexDirection: 'row',
        }}>

            {tailorList.slice(0,3).map((tailor) => {
                console.log("CROITORII", tailor);
                return (
                <StaffCard name = {tailor.name} staffRole = {tailor.role} img = {tailor.avatarUrl}/>
            )})}
        </Box>
        </Box>
    );
};

export default StafFSection;
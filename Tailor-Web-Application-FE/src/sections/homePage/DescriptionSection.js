/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';

import sewingMan from "../../assets/Croitor.jpg";
import shape1 from "../../assets/shape-1.png";
import shape2 from "../../assets/shape-2.png";

const DescriptionSection = () => {
    return (
        <Box sx = {{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            width : '100%',
            height: '650px',
        }}>
             <Box className = "LeftImage"
             sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width : '45%',
                mx: '20px',
                 }}>
                    <img src = {sewingMan} alt = "" height = "400px"/>
            </Box>

            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'left',
                flexDirection: 'column',
                width : '55%',
                mx: '20px'
                }}>
                    
                <img src = {shape1} alt = "" width = "60px"/>
                <Typography sx = {{fontSize: '20px', mb: '10px'}}>Artă în Croitorie</Typography>

                <Typography sx = {{fontSize : "45px"}}> Un atelier al eleganței</Typography>

                <Typography sx = {{fontSize : "20px", my: '20px'}}>Atelierul de croitorie are o reputație remarcabilă, dedicată creării și realizării de creații vestimentare personalizate pentru clienții săi exigenți. Cu o experiență vastă în domeniul croitoriei și o echipă talentată de meșteri artizani, atelierul se remarcă prin expertiza sa în confecționarea hainelor de cea mai înaltă calitate.</Typography>

                <Box sx = {{display : 'flex', flexDirection: 'row', my: '5px', mt: '10px'}}>
                    <img src = {shape2} alt = "" width = "20px" height= "10px" />
                    <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px'}} > Expertiză artizanală înaltă în confecționarea hainelor de calitate.</Typography>
                </Box>

                <Box sx = {{display : 'flex', flexDirection: 'row', my: '5px'}}>
                    <img src = {shape2} alt = "" width = "20px" height= "10px" />
                    <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px'}} > Designuri unice și elegante, adaptate stilului și preferințelor fiecărui client.</Typography>
                </Box>

                <Box sx = {{display : 'flex', flexDirection: 'row', my: '5px'}}>
                    <img src = {shape2} alt = "" width = "20px" height= "10px" />
                    <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px'}} > Materiale fine și atenție meticuloasă la detalii.</Typography>
                </Box>

                <Box sx = {{display : 'flex', flexDirection: 'row', my: '5px'}}>
                    <img src = {shape2} alt = "" width = "20px" height= "10px" />
                    <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px'}} > Experiență personalizată și servicii de consultanță atentă pentru a îndeplini dorințele clienților.</Typography>
                </Box>
            </Box>
        </Box>
    );
};

export default DescriptionSection;
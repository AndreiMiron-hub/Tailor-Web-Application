/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';

import IronOutlinedIcon from '@mui/icons-material/IronOutlined';

import shape1 from "../../assets/shape-1.png";
import shape2 from "../../assets/shape-2.png";
import ServiceMotivationImage from "../../assets/ServicesMotivationImage.jpg"


const ServiceMotivationSection = () => {
    return (
        <Box sx = {{
            display: 'flex',
            flexDirection: 'row',
            height: '670px',
        }}> 
        <Box sx = {{
            display:'flex',
            height: '100%',
            width: '20px',
            backgroundColor: '#DEB18A',
        }}/>
        <Box sx = {{
            display: 'flex',
            flexDirection: 'row',
            width: '100%',
            height: '100%',
            backgroundColor: '#454456',
        }}>

            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'left',
                flexDirection: 'column',
                width : '50%',
                mx: '20px',
                }}> 

                <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'left',
                flexDirection: 'column',
                width : '100%',
                mx: '20px',
                }}>
                    
                    <img src = {shape1} alt = "" width = "60px" style={{ marginBottom: '15px'}}/>
                    <Typography sx = {{fontSize : "45px", color: 'white'}}>Recenzii excelente pentru serviciile noastre de croitorie</Typography>

                    <Typography sx = {{fontSize : "20px", my: '20px', color: 'white'}}>Firma noastră de croitorie primește exclusiv recenzii excelente de la clienți mulțumiți. Suntem apreciați pentru serviciile noastre excepționale, atenția la detalii și calitatea lucrărilor. Iată câteva dintre comentariile noastre de top:</Typography>

                    <Box sx = {{display : 'flex', flexDirection: 'row', my: '10px', mt: '10px'}}>
                        <img src = {shape2} alt = "" width = "20px" height= "10px" />
                        <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px', color: 'white'}} > "Experiență uimitoare! Hainele mele arată și se simt perfect."</Typography>
                    </Box>

                    <Box sx = {{display : 'flex', flexDirection: 'row',  my: '10px'}}>
                        <img src = {shape2} alt = "" width = "20px" height= "10px" />
                        <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px', color: 'white'}} > "Croitorii lor sunt adevărați artiști. Nu am mai purtat niciodată haine atât de bine croite."</Typography>
                    </Box>

                    <Box sx = {{display : 'flex', flexDirection: 'row', my: '10px'}}>
                        <img src = {shape2} alt = "" width = "20px" height= "10px" />
                        <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px', color: 'white'}} >"Serviciu impecabil și termene de livrare respectate. Recomand cu încredere!"</Typography>
                    </Box>

                    <Box sx = {{display : 'flex', flexDirection: 'row', my: '10px'}}>
                        <img src = {shape2} alt = "" width = "20px" height= "10px" />
                        <Typography sx= {{fontSize: "18px", mt : '-8px', ml: '5px', color: 'white'}} > "Recomand cu căldură! Au transformat ideile mele în piese vestimentare de excepție."</Typography>
                    </Box>
                </Box> 
            </Box>

            <Box sx = {{
                display:'flex',
                width: '50%',
                position: 'relative',
            }}>
                
                <Box sx = {{
                    position: 'absolute',
                    bottom: '0',
                    left: '0',
                    display: 'flex',
                    backgroundColor: '#DEB18A',
                    width: '150px',
                    height: '200px',
                    justifyContent:'center',
                    alignItems: 'center',
                }}>
                    <IronOutlinedIcon sx = {{ fontSize: '100px', color: 'white'}}/> 
                </Box>

                <img
                    src={ServiceMotivationImage}
                    alt=""
                    style={{
                    objectFit: 'cover',
                    width: '100%',
                    height: '100%',
                    }}/>

             </Box>
        </Box>
        </Box>
    )
};

export default ServiceMotivationSection;
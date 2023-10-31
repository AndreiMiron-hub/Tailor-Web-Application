/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';



const ServiceCard= ({ service, title, content, imageName }) => {
    return (
        <Box sx = {{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'column',
            backgroundColor: 'white',
            width: '350px',
            height: '450px',
            border: '2px dotted #DEB18A',
            mx: '2rem',
            mt: '20px',
        }}>
            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width : '250px',
                height: '250px',
                borderRadius: '50%',
                border: '2px dotted #DEB18A',
                }}>
                <Box sx = {{
                    className : "CircleImage",
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    overflow: 'hidden',
                    width: '200px',
                    height: '200px',
                    borderRadius: '50%',
                }}>

                     <img 
                        src = {service.images}
                        alt=""
                        style = {{
                            height:'100%',
                        }}/>
                </Box>
            </Box>

            <Typography sx =  {{
                display:'flex',
                fontSize: '25px',
                fontWeight: 'bold',

            }}> {service.name} </Typography>

            <Typography sx  ={{
                display:'flex',
                width: '250px',
                textAlign: 'center',
            }}> {service.description} </Typography>

        </Box>
    );
};

export default ServiceCard;
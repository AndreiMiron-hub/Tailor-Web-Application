/* eslint-disable arrow-body-style */
/* eslint-disable react/prop-types */
import { Box } from '@mui/material'
import React from 'react'

const Carousel = ({images}) => (
    <Box                
    sx = {{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column',
        border:'2px solid red',
        width: '98vw',
        height: '400px',
        maxWidth: '1280px',
    }}>
        <Box className = "carousel_wrapper"
        sx ={{
            position: 'relative',
            // width:'100%',
            // height: '100%',
        }}>
            {images.map((image, index) => {
                return (
                            <Box key = {index} className = "carousel_card"
                                sx = {{
                                        display: 'flex',
                                        flex: 1,
                                        position: 'absolute',
                                        width:'100%',
                                        borderRadius: '20px'
                                    }}>
                                    <img src = {image.image} alt = ""/>
                                    <Box className = "card_oferlay" 
                                    sx ={{
                                        // position: 'absolute',
                                        // width: "100%",
                                        // height: '100%',
                                        // backgroundColor: 'rgba(0,0,0,0.5)',
                                        // padding: '40px 30px',
                                        // alignItems: 'flex-end',
                                    }}>
                                        <h2 className = "card_title">{image.title}</h2>
                                    </Box>
                            </Box>
                        );
            })}
        </Box>
    </Box>
  )

export default Carousel;
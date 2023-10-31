/* eslint-disable arrow-body-style */
import { useNavigate  } from 'react-router-dom';
import { IconButton, Box, Typography} from '@mui/material';
import { FormattedMessage } from 'react-intl';

import PlayArrowIcon from '@mui/icons-material/PlayArrow';
// import AddIcCallIcon from '@mui/icons-material/AddIcCall';

import VideoBackground from "../../assets/VideoBackground.jpg";

const VideoSection = () => {
    const history = useNavigate();

  const handleClick = () => {
    // Replace 'VIDEO_ID' with the actual YouTube video ID or URL
    const videoId = '1pi2kI8-b1A&ab_channel=ProjektVisuals';
    const videoUrl = `https://www.youtube.com/watch?v=${videoId}`;

    // Open the YouTube video in a new tab/window
    window.open(videoUrl, '_blank');
  };
    return (
        <Box sx = {{
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
            overflow: 'hidden',
            width : '100%',
            height: '450px',
            bgcolor: 'lightblue',
            py: '30px',  
            position: 'relative',
            }}>

            <img src = {VideoBackground} alt = ''/>
            <Box sx = {{
                display: 'flex',
                alignItems: 'center',
                flexDirection: 'column',
                position: 'absolute', 
                top: '50%', 
                left: '50%',
                transform: 'translate(-50%, -50%)',
                }}> 

                <IconButton
                size = "large"
                sx={{
                    backgroundColor: '#3A3949',
                    color: 'white',
                    '&:hover': {
                    backgroundColor: '#DEB18A',
                    },
                }}
                onClick={handleClick}
                >
            
                <PlayArrowIcon />

                </IconButton>

                <Typography sx = {{
                    width: '60rem',
                    textAlign: 'center',
                    color: 'white',
                    fontWeight: 'bold',
                    textShadow: '2px 2px 4px rgba(0, 0, 0, 1)',
                    fontSize: '50px',
                }}> <FormattedMessage id="lbl.videoText.about"/></Typography>
            </Box>
           
        </Box>
    )
};

export default VideoSection;
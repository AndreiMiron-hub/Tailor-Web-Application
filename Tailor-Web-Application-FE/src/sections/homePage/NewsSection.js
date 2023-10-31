/* eslint-disable arrow-body-style */
/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { NavLink as RouterLink, useNavigate } from 'react-router-dom';
import { FormattedMessage } from 'react-intl';

import { Box, Typography } from '@mui/material';
import { NewsCard } from '../../components';

import shape1 from "../../assets/shape-1.png";
import img from "../../assets/Carousel_2.jpg";

import { 
    setNewsError,
    setNewsStatus,
    setSelectedNews,
    getNews
  } from '../../config/redux/slices/NewsSlice';

const NewsSection = () => {
    const [openFilter, setOpenFilter] = useState(false);
  const dispatch = useDispatch();
  const [error, setError] = useState(null);

  const handleOpenFilter = () => {
    setOpenFilter(true);
  };

  const handleCloseFilter = () => {
    setOpenFilter(false);
  };

  const {
      loading,
      news,
      newsError,
      news_status,
    } = useSelector((state) => state.news)
  
  useEffect(() => {
    if(!news && !(news_status === 'failed')) 
    {
      dispatch(getNews());
    }
    if(news_status === 'failed' && newsError) {
      setError(true);
    }
    if(news && newsError && news_status === 'failed')
    {
      dispatch(setNewsError(null));
      dispatch(setNewsStatus(null));
    }
  }, [news, news_status, dispatch, newsError]);


  const onSelectedNews = (news) => {
    dispatch(setSelectedNews(news));
  };
    return (
        <Box sx = {{
            display:'flex',
            justifyContent: 'center',
            alignItems: 'center',
            width: '100%',
            height: '600px',
            bgcolor: '#FBF7F4',
        }}>
            <Box sx = {{
                 display:'flex',
                 justifyContent: 'center',
                 alignItems: 'left',
                 flexDirection: 'column',
                 padding: '40px',
                 width: '30rem',
                 height: '100%',
                 backgroundColor: 'white',
                }}>
                    <img src = {shape1} alt = "" width = "70px"/>
                    <Typography sx = {{                  
                        textAlign: 'left',
                        fontSize: '40px',
                        fontWeight: 'bold',
                        my: '10px',
                        }}> 
                        <FormattedMessage id="lbl.news.newsSection"/>
                    </Typography>

                    <Typography sx = {{                  
                        textAlign: 'left',
                        fontSize: '25px',
                        my: '10px',
                        }}> 
                        <FormattedMessage id="lbl.newsLonger.newsSection"/>
                    </Typography>

                    <Typography sx = {{                  
                        textAlign: 'left',
                        my: '20px',
                        textIndent: '20px',
                        '&::first-line': {
                        textIndent: '0',
                        },
                        }}> 
                        Descoperă moda, croitoria și inovațiile într-o colecție captivantă de articole despre haine și tendințe.
                    </Typography>

            </Box> 

            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width: '70rem',
                height: '100%',
                backgroundColor: '#F7F3F0',
            }}>
                 {!loading &&
                  news &&
                  news.slice(0, 3).map((article, index) => {
                      return <NewsCard key={index + article.id} news={article} onSelected={onSelectedNews}/>
                  })}
            </Box>
        </Box>
    );
};

export default NewsSection;
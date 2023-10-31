/* eslint-disable camelcase */
import { Helmet } from 'react-helmet-async';
import PropTypes from 'prop-types';
import React, { useState, useEffect } from 'react';
import { NavLink as RouterLink, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
// @mui
import { Grid, Button, Container, Stack, Typography } from '@mui/material';
// components
import { FormattedMessage } from 'react-intl';

import Iconify from '../../components/iconify';
import { BlogPostCard, BlogPostsSort, BlogPostsSearch } from '../../sections/@dashboard/blog';
// mock
import POSTS from '../../_mock/blog';
import { 
  setNewsError,
  setNewsStatus,
  setSelectedNews,
  getNews
} from '../../config/redux/slices/NewsSlice';
import {
  ArticleModal
} from '../../components'
// ----------------------------------------------------------------------

const SORT_OPTIONS = [
  { value: 'latest', label: 'Latest' },
  { value: 'popular', label: 'Popular' },
  { value: 'oldest', label: 'Oldest' },
];

// ----------------------------------------------------------------------

export default function BlogPage() {
  const [openFilter, setOpenFilter] = useState(false);
  const dispatch = useDispatch();

  const [showModal, setShowModal] = useState(false);  

  const [error, setError] = useState(null);

  const handleOpenFilter = () => {
    setOpenFilter(true);
  };

  const handleCloseFilter = () => {
    setOpenFilter(false);
  };


  const onAddClick = () => {
    setShowModal(true);
  };

  const handleOnClose = () => {
    setShowModal(false);
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
    <>
      <Helmet>
        <title> Blog | Tailor Web App </title>
      </Helmet>

      <Container>
        <Stack direction="row" alignItems="center" justifyContent="space-between" mb={5}>
          <Typography variant="h4" gutterBottom>
            <FormattedMessage id="lbl.dashboard.articles"/>
          </Typography>

          <Button variant="contained" startIcon={<Iconify icon="eva:plus-fill" />} onClick = {onAddClick}>
            <FormattedMessage id="lbl.dashboard.newArticle"/>
          </Button>
        </Stack>

        <Stack mb={5} direction="row" alignItems="center" justifyContent="space-between">
          <BlogPostsSearch posts={POSTS} />
          <BlogPostsSort options={SORT_OPTIONS} />
        </Stack>

        <Grid container spacing={3}>
          {!loading &&
                  news &&
                  news.slice(0, 4).map((article, index) => {
                      return <BlogPostCard key={index + article.id} post={article} onSelected={onSelectedNews}/>
                  })}
        </Grid>

        {showModal && <ArticleModal open={showModal} onClose={handleOnClose}/>}
      </Container>
    </>
  );
}

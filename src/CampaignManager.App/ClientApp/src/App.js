import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import { Categories } from './pages/templates/Categories';
import { Coalitions } from './pages/templates/Coalitions';
import { Countries } from './pages/templates/Countries';
import { Entities } from './pages/templates/Entities';
import { Services } from './pages/templates/Services';
import { Subcategories } from './pages/templates/Subcategories';

import './custom.css';
import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';
import { Create } from './pages/campaigns/Create';
import { Configure } from './pages/campaigns/Configure';
import { Campaign } from './pages/campaigns/Campaign';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <AuthorizeRoute path='/create' component={Create} />
        <AuthorizeRoute path='/configure/:id' component={Configure} />
        <AuthorizeRoute path='/campaign/:id' component={Campaign} />
        <AuthorizeRoute path='/categories' component={Categories} />
        <AuthorizeRoute path='/coalitions' component={Coalitions} />
        <AuthorizeRoute path='/countries' component={Countries} />
        <AuthorizeRoute path='/entities' component={Entities} />
        <AuthorizeRoute path='/services' component={Services} />
        <AuthorizeRoute path='/subcategories' component={Subcategories} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}

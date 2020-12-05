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
import { Objects } from './pages/templates/Objects';
import { Services } from './pages/templates/Services';
import { Statuses } from './pages/templates/Statuses';
import { Subcategories } from './pages/templates/Subcategories';

import './custom.css';
import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <AuthorizeRoute path='/categories' component={Categories} />
        <AuthorizeRoute path='/coalitions' component={Coalitions} />
        <AuthorizeRoute path='/countries' component={Countries} />
        <AuthorizeRoute path='/objects' component={Objects} />
        <AuthorizeRoute path='/services' component={Services} />
        <AuthorizeRoute path='/statuses' component={Statuses} />
        <AuthorizeRoute path='/subcategories' component={Subcategories} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}

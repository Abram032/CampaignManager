import React, { Component } from 'react';
import { 
  Collapse, 
  Container, 
  Navbar, 
  NavbarBrand, 
  NavbarToggler, 
  NavItem,
  NavLink, 
  UncontrolledDropdown, 
  DropdownToggle, 
  DropdownMenu, 
  DropdownItem 
} from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import authService from './api-authorization/AuthorizeService';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      isAuthenticated: false
    };
  }

  async componentDidMount() {
    this.setState({ isAuthenticated: await authService.isAuthenticated() });
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  renderTemplates() {
    if(!this.state.isAuthenticated) {
      return null;
    }

    return (
      <UncontrolledDropdown nav inNavbar>
        <DropdownToggle className="nav-link" nav caret>Templates</DropdownToggle>
        <DropdownMenu>
          <DropdownItem href="/categories">Categories</DropdownItem>
          <DropdownItem href="/coalitions">Coalitions</DropdownItem>
          <DropdownItem href="/countries">Countries</DropdownItem>
          <DropdownItem href="/objects">Objects</DropdownItem>
          <DropdownItem href="/services">Services</DropdownItem>
          <DropdownItem href="/statuses">Statuses</DropdownItem>
          <DropdownItem href="/subcategories">Subcategories</DropdownItem>
        </DropdownMenu>
      </UncontrolledDropdown>
    );
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Campaign Manager</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                {this.renderTemplates()}
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                </NavItem>
                <LoginMenu>
                </LoginMenu>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

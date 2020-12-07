import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import { Nav, NavItem, NavLink, TabContent, TabPane, Row, Col } from 'reactstrap';

export class Campaign extends Component {
  constructor(props) {
    super(props);
    this.state = {
      title: 'Campaign',
      campaign: { data: null },
      activeTab: ''
    }
    this.id = this.props.match.params.id;
    this.setActiveTab = this.setActiveTab.bind(this);
    this.renderCampaignForm = this.renderCampaignForm.bind(this);
  }

  async componentDidMount() {
    this.setState({ campaign: await campaignStore.byKey(this.id) });
    this.setState({ title: `Campaign - ${this.state.campaign.data.name}` });
  }

  setActiveTab(value) {
    this.setState({ activeTab: value });
  }

  render() {
    return (
      <>
        <h1 className="display-4 mb-5">{this.state.title}</h1>
        <Nav tabs>
          <NavItem>
            <NavLink onClick={() => { this.setActiveTab('overview') }}>Overview</NavLink>
          </NavItem>
          <NavItem>
            <NavLink onClick={() => { this.setActiveTab('missions') }}>Missions</NavLink>
          </NavItem>
          <NavItem>
            <NavLink onClick={() => { this.setActiveTab('locations') }}>Locations</NavLink>
          </NavItem>
        </Nav>
        <TabContent activeTab={this.state.activeTab}>
          <TabPane tabId={'overview'}>

          </TabPane>
          <TabPane tabId={'missions'}>
            
          </TabPane>
          <TabPane tabId={'locations'}>
            
          </TabPane>
        </TabContent>
      </>
    );
  }
};

export default Campaign;
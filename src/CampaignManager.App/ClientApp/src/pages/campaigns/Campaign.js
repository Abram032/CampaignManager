import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import CampaignForm from '../../libs/components/forms/CampaignForm';
import { Nav, NavItem, NavLink, TabContent, TabPane, Row, COl } from 'reactstrap';
import Col from 'reactstrap/lib/Col';

export class Campaign extends Component {
  constructor(props) {
    super(props);
    this.state = {
      title: 'Campaign',
      campaign: { data: null },
      activeTab: ''
    }
    this.id = this.props.match.params.id;
    this.onSubmit = this.onSubmit.bind(this);
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
  
  onSubmit(event) {
    campaignStore.update(this.id, this.state.campaign.data);
    debugger;
  }

  renderCampaignForm() {
    return (
      <Row className='mb-5'>
        <Col>
          <p className="lead mt-3 mb-3">Configuration</p>
          <form onSubmit={this.onSubmit}>
            <CampaignForm campaign={this.state.campaign.data} submitText={'Save'}/>
          </form>
        </Col>
      </Row>
    )
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
          <NavItem>
            <NavLink onClick={() => { this.setActiveTab('factions') }}>Factions</NavLink>
          </NavItem>
          <NavItem>
            <NavLink onClick={() => { this.setActiveTab('prices') }}>Prices</NavLink>
          </NavItem>
          <NavItem>
            <NavLink onClick={() => { this.setActiveTab('configuration') }}>Configuration</NavLink>
          </NavItem>
        </Nav>
        <TabContent activeTab={this.state.activeTab}>
          <TabPane tabId={'overview'}>

          </TabPane>
          <TabPane tabId={'missions'}>
            
          </TabPane>
          <TabPane tabId={'locations'}>
            
          </TabPane>
          <TabPane tabId={'factions'}>
            
          </TabPane>
          <TabPane tabId={'prices'}>
            
          </TabPane>
          <TabPane tabId={'configuration'}>
            {this.renderCampaignForm()}
          </TabPane>
        </TabContent>
      </>
    );
  }
};

export default Campaign;
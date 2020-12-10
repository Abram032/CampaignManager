import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import { factionStore } from '../../stores/factionStore';
import { locationStore } from '../../stores/locationStore';
import { Nav, NavItem, NavLink, TabContent, TabPane, Row, Col, Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import SelectBox from 'devextreme-react/select-box';
import LocationForm from '../../libs/components/forms/LocationForm';

export class Campaign extends Component {
  constructor(props) {
    super(props);

    this.id = this.props.match.params.id;

    this.state = {
      title: 'Campaign',
      campaign: { data: null },
      options: {
        expr: 'campaignId',
        value: this.id  
      },
      faction: null,
      activeTab: ''
    }
    
    this.setActiveTab = this.setActiveTab.bind(this);
    this.onFactionChanged = this.onFactionChanged.bind(this);

    this.renderOverview = this.renderOverview.bind(this);
    this.renderMissions = this.renderMissions.bind(this);
    this.renderLocations = this.renderLocations.bind(this);
  }

  async componentDidMount() {
    this.setState({ campaign: await campaignStore.byKey(this.id) });
    this.setState({ title: `Campaign - ${this.state.campaign.data.name}` });
  }

  setActiveTab(value) {
    this.setState({ activeTab: value });
  }

  onFactionChanged() {

  }

  renderOverview() {
    return (
      <>
        <p className='lead mt-3 mb-3'>Overview placeholder</p>
      </>
    )
  }

  renderMissions() {
    return (
      <>
        <p className='lead mt-3 mb-3'>Missions placeholder</p>
      </>
    )
  }

  renderLocations() {
    return (
      <>
        <p className='lead mt-3 mb-3'>Locations</p>
        <LocationForm store={locationStore} options={this.state.options} campaignId={this.id} />
      </>
    )
  }

  render() {
    return (
      <>
        <h1 className='display-4 mb-5'>{this.state.title}</h1>
        <Row style={{ display: 'flex', justifyContent: 'flex-end' }}>
          <Link to={`/configure/${this.id}`} className='btn btn-warning mr-3'>Configuration</Link>
          <SelectBox
            displayExpr='name'
            dataSource={factionStore}
            value={this.state.faction}
            onValueChanged={this.onFactionChanged}
          />
        </Row>
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
            {this.renderOverview()}
          </TabPane>
          <TabPane tabId={'missions'}>
            {this.renderMissions()}
          </TabPane>
          <TabPane tabId={'locations'}>
            {this.renderLocations()}
          </TabPane>
        </TabContent>
      </>
    );
  }
};

export default Campaign;
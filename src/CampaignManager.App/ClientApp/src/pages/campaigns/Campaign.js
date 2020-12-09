import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import { factionStore } from '../../stores/factionStore';
import { Nav, NavItem, NavLink, TabContent, TabPane, Row, Col, Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import SelectBox from 'devextreme-react/select-box';

export class Campaign extends Component {
  constructor(props) {
    super(props);
    this.state = {
      title: 'Campaign',
      campaign: { data: null },
      faction: null,
      activeTab: ''
    }
    this.id = this.props.match.params.id;
    this.setActiveTab = this.setActiveTab.bind(this);
    this.onFactionChanged = this.onFactionChanged.bind(this);
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

  render() {
    return (
      <>
        <h1 className="display-4 mb-5">{this.state.title}</h1>
        <Row style={{ display: 'flex', justifyContent: 'flex-end' }}>
          <Link to={`/configure/${this.id}`} className='btn btn-warning mr-3'>Configuration</Link>
          <SelectBox
            displayExpr="name"
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
import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import CampaignForm from '../../libs/components/forms/CampaignForm';
import { Nav, NavItem, NavLink, TabContent, TabPane, Row, Col } from 'reactstrap';
import FactionForm from '../../libs/components/forms/FactionForm';
import { factionStore } from '../../stores/factionStore';

export class Configure extends Component {
  constructor(props) {
    super(props);
    
    this.id = this.props.match.params.id;

    this.state = {
      title: 'Configure Campaign',
      campaign: { data: null },
      factionOptions: { 
        expr: 'campaignId',
        value: this.id  
      },
      activeTab: ''
    }
    this.onSubmit = this.onSubmit.bind(this);
    this.renderCampaignForm = this.renderCampaignForm.bind(this);
    this.renderFactions = this.renderFactions.bind(this);
  }

  async componentDidMount() {
    this.setState({ campaign: await campaignStore.byKey(this.id) });
    this.setState({ title: `Configure Campaign - ${this.state.campaign.data.name}` });
  }
  
  onSubmit(event) {
    campaignStore.update(this.id, this.state.campaign.data);
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

  renderFactions() {
    return (
      <>
        <p className="lead mt-3 mb-3">Factions</p>
        <FactionForm store={factionStore} options={this.state.factionOptions} campaignId={this.id} />
      </>
    )
  }

  render() {
    return (
      <>
        <h1 className="display-4">{this.state.title}</h1>
        {this.renderCampaignForm()}
        {this.renderFactions()}
      </>
    );
  }
};

export default Configure;
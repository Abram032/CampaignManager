import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import CampaignForm from '../../libs/components/forms/CampaignForm';
import { Nav, NavItem, NavLink, TabContent, TabPane, Row, Col } from 'reactstrap';
import FactionForm from '../../libs/components/forms/FactionForm';
import CostsForm from '../../libs/components/forms/CostsForm';
import { factionStore } from '../../stores/factionStore';
import { entityCostStore } from '../../stores/entityCostStore';

export class Configure extends Component {
  constructor(props) {
    super(props);
    
    this.id = this.props.match.params.id;

    this.state = {
      title: 'Configure Campaign',
      campaign: { data: null },
      options: { 
        expr: 'campaignId',
        value: this.id  
      },
      activeTab: ''
    }
    this.onSubmit = this.onSubmit.bind(this);
    this.renderCampaignForm = this.renderCampaignForm.bind(this);
    this.renderFactions = this.renderFactions.bind(this);
    this.renderCosts = this.renderCosts.bind(this);
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
          <p className='lead mt-3 mb-3'>Configuration</p>
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
        <p className='lead mt-3 mb-3'>Factions</p>
        <FactionForm store={factionStore} options={this.state.options} campaignId={this.id} />
      </>
    )
  }

  renderCosts() {
    return (
      <>
        <p className='lead mt-3 mb-3'>Entity costs</p>
        <CostsForm store={entityCostStore} options={this.state.options} campaignId={this.id} />
      </>
    )
  }

  render() {
    return (
      <>
        <h1 className='display-4'>{this.state.title}</h1>
        {this.renderCampaignForm()}
        {this.renderFactions()}
        {this.renderCosts()}
      </>
    );
  }
};

export default Configure;
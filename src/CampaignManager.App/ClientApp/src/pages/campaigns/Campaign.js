import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import CampaignForm from '../../libs/components/forms/CampaignForm';

export class Campaign extends Component {
  constructor(props) {
    super(props);
    this.state = {
      title: 'Campaign',
      campaign: { data: null }
    }
    this.id = this.props.match.params.id;
    this.onSubmit = this.onSubmit.bind(this);
  }

  async componentDidMount() {
    this.setState({ campaign: await campaignStore.byKey(this.id) });
    this.setState({ title: `Campaign - ${this.state.campaign.data.name}` });
  }
  
  onSubmit(event) {
    campaignStore.update(this.id, this.state.campaign.data);
    debugger;
  }

  render() {
    return (
      <>
        <h1 className="display-4 mb-5">{this.state.title}</h1>
        <form onSubmit={this.onSubmit}>
          <CampaignForm campaign={this.state.campaign.data} submitText={'Save'}/>
        </form>
      </>
    );
  }
};

export default Campaign;
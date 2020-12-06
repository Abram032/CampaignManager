import React, { Component } from 'react';
import { campaignStore } from '../../stores/campaignStore';
import CampaignForm from '../../libs/components/forms/CampaignForm';

const title = 'Create campaign';

export class CreateCampaign extends Component {
  constructor(props) {
    super(props);
    this.state = {
      campaign: {}
    }

    this.onSubmit = this.onSubmit.bind(this);
  }
  
  onSubmit(event) {
    campaignStore.insert(this.state.campaign);
  }

  render() {
    return (
      <>
        <h1 className="display-4">{title}</h1>
        <form onSubmit={this.onSubmit}>
          <CampaignForm campaign={this.state.campaign} submitText={'Create'}/>
        </form>
      </>
    );
  }
};

export default CreateCampaign;
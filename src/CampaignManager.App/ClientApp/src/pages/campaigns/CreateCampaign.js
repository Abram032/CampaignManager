import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';

const title = 'Create campaign';

export class CreateCampaign extends Component {

    render() {
      return (
        <>
          <h1 className="display-4">{title}</h1>
        </>
      );
    }
  };
  
  export default CreateCampaign;
import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { serviceStore } from '../../stores/serviceStore';
import { 
  Column,
  StringLengthRule,
  RequiredRule
} from 'devextreme-react/data-grid';

const columns = (
  [
    <Column dataField='id' caption='Id' dataType='number' allowEditing={false} />,
    <Column dataField='name' caption='Name' dataType='string'>
      <RequiredRule />
      <StringLengthRule min={1} max={100} />
    </Column>
  ]
);

export class Services extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <DataGridExp columns={columns} store={serviceStore}/>
      </>
    );
  }
};

export default Services;
import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { serviceStore } from '../../stores/serviceStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]}
];

export class Services extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <h1 className="display-4">Services</h1>
        <DataGridExp columns={columns} store={serviceStore}/>
      </>
    );
  }
};

export default Services;
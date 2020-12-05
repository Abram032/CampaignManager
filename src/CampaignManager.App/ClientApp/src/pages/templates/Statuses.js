import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { statusStore } from '../../stores/statusStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]}
];

export class Statuses extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <h1 className="display-4">Statuses</h1>
        <DataGridExp columns={columns} store={statusStore}/>
      </>
    );
  }
};

export default Statuses;
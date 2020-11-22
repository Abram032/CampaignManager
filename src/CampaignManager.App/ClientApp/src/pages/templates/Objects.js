import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { objectStore } from '../../stores/objectStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
      { type: 'required' },
      { type: 'stringLength', min: 1, max: 100 }
  ] }
];

export class Objects extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <DataGridExp columns={columns} store={objectStore}/>
      </>
    );
  }
};

export default Objects;
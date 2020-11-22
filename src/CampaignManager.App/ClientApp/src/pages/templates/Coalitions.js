import React, { Component } from 'react';
import DataGrid from '../../libs/components/forms/DataGrid';
import DataGridv2 from '../../libs/components/forms/DataGridv2';
import { coalitionStore } from '../../stores/coalitionStore';

const apiUri = `${window.location.origin}/api/coalition`;
const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number' },
  { dataField: 'name', caption: 'Name', dataType: 'string' },
  { dataField: 'color', caption: 'Color', dataType: 'string' },
];

export class Coalitions extends Component {
  constructor(props) {
    super(props);
  };

  rowDetail = ({ row }) => (
    <div>
      Details for
      {' '}
      {row.id}
      {' - '}
      {row.name}
      {' of type '}
      {row.type}
    </div>
  );

  render() {
    return (
      <>
        <DataGridv2 columns={columns} rowDetail={this.rowDetail} apiUri={apiUri} store={coalitionStore}/>
      </>
    );
  }
};

export default Coalitions;
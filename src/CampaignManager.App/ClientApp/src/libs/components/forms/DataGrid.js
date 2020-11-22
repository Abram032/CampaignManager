import React, { Component } from 'react';
import {
  EditingState,
  SortingState,
  IntegratedSorting,
  PagingState,
  IntegratedPaging,
  FilteringState,
  IntegratedFiltering,
  GroupingState,
  IntegratedGrouping,
  RowDetailState
} from '@devexpress/dx-react-grid';
import {
  Grid,
  Table,
  TableHeaderRow,
  TableGroupRow,
  TableEditRow,
  TableEditColumn,
  PagingPanel,
  TableFilterRow,
  GroupingPanel,
  DragDropProvider,
  Toolbar,
  TableColumnReordering,
  TableColumnResizing,
  ColumnChooser,
  TableColumnVisibility,
  TableRowDetail
} from '@devexpress/dx-react-grid-bootstrap4';

export class DataGrid extends Component {

  constructor(props) {
    super(props);
    this.state = { 
      columns: this.props.columns,
      rows: this.props.rows ?? [],
      grouping: this.props.grouping ?? [],
      currentPage: this.props.currentPage ?? 1,
      pageSize: this.props.pageSize ?? 10
    }
  }
  
  async componentDidMount() {
    const response = await fetch(this.props.apiUri);
    const data = await response.json();
    this.setState({ rows: data });
  };

  sendRequest = async(uri, method, data) => {
    let response = await fetch(uri, {
      method: method,
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data) ?? null
    });
    if(response.status >= 200 && response.status <= 300) {
      return await response.json();
    }
    console.error(await response.json());
    return null; 
  };

  commitChanges = async ({ added, changed, deleted }) => {
    let rows = this.state.rows;
    if (added) {
      let element = added[0];
      let response = await this.sendRequest(this.props.apiUri, 'POST', element);
      if(response) {
        rows.push(response);
      }
    }
    if (changed) {
      rows = this.state.rows.map(row => (changed[row.id] ? { ...row, ...changed[row.id] } : row));
      let changedRows = rows.filter(row => !this.state.rows.map(currRow => currRow.id).includes(row.id));

      await changedRows.forEach(async element => {
        let response = await fetch(`${this.props.apiUri}/${element.id}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(element)
        });
        let result = await response.body.json();
      });
    }
    if (deleted) {
      const deletedSet = new Set(deleted);
      rows = this.state.rows.filter(row => !deletedSet.has(row.id));

      let changedRows = rows.filter(row => !this.state.rows.map(currRow => currRow.id).includes(row.id));
      changedRows.forEach(async element => {
        let response = await fetch(`${this.props.apiUri}/${element.id}`, {
          method: 'DELETE'
        });
        let result = await response.body.json();
      });
    }
    debugger;
    this.setRows(rows);
  };
  getRowId = row => row.id;
  setRows = (changedRows) => this.setState({ rows: changedRows });
  setGrouping = (grouping) => this.setState({ grouping: grouping });
  setCurrentPage = (page) => this.setState({ currentPage: page });
  setPageSize = (size) => this.setState({ pageSize: size });

  rowDetails = () => {
    if(this.props.rowDetail) {
      return (
        <TableRowDetail
          contentComponent={this.props.rowDetail}
        />
      )
    }
    return null;
  };
  
  render() {
    return (
        <div className="card">
          <Grid
            rows={this.state.rows}
            columns={this.state.columns}
            getRowId={this.getRowId}
          >
            <DragDropProvider />
            <EditingState
              onCommitChanges={this.commitChanges}
            />
            <SortingState
              defaultSorting={[{ columnName: this.state.columns[0].name, direction: 'asc' }]}
            />
            <IntegratedSorting />
            <PagingState
              currentPage={this.state.currentPage}
              onCurrentPageChange={this.setCurrentPage}
              pageSize={this.state.pageSize}
              onPageSizeChange={this.setPageSize}
            />
            <IntegratedPaging />
            <FilteringState defaultFilters={[]} />
            <IntegratedFiltering />
            <GroupingState
              grouping={this.state.grouping}
              onGroupingChange={this.setGrouping}
            />
            <IntegratedGrouping />
            <RowDetailState
              defaultExpandedRowIds={[]}
            />
            <Table />
            <TableColumnReordering
              defaultOrder={this.state.columns.map((val) => ( val.name ))}
            />
            <TableColumnVisibility
              defaultHiddenColumnNames={[]}
            />
            <TableColumnResizing defaultColumnWidths={this.state.columns.map((val) => ( { columnName: val.name, width: 200 } ))} />
            
            <TableGroupRow />
            <TableHeaderRow showSortingControls showGroupingControls />
            <TableEditColumn showAddCommand showEditCommand showDeleteCommand />
            <PagingPanel
              pageSizes={[1, 2, 3, 5, 10, 15]}
            />
            <TableFilterRow />
            {this.rowDetails()}
            <TableEditRow />
            <Toolbar />
            <ColumnChooser />
            <GroupingPanel showGroupingControls />
          </Grid>
        </div>
      );
  }
};

export default DataGrid;

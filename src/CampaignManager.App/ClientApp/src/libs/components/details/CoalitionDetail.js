import React from 'react';

export class CoalitionDetail extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    let { name, color } = this.props.data.data;
    return (
      <React.Fragment>
        <div className="master-detail-caption">
          {`${name} - ${color}`}
        </div>
      </React.Fragment>
    );
  }
}

export default CoalitionDetail;

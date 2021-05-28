  - name: {remark}
    type: ss
    server: {domain}
    port:{port}
    cipher: {method}
    password: {passwd}
    udp: true
    plugin: obfs
    plugin-opts:
      mode: http
      host: {obfs_params}
